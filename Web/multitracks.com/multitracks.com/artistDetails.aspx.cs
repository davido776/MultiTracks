using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Default : MultitracksPage
{
    private readonly object artistImage;

    protected void Page_Load(object sender, EventArgs e)
    {
        var sql = new SQL();

        try
        {
            var artistId = Request.QueryString["id"];

            sql.Parameters.Add("@artistID", artistId);

            var data = sql.ExecuteStoredProcedureDT("GetArtistDetails");

            var x = DataTableExtensions.ToDynamic(data);

            var rowCount = DB.RowCount(data);

            var detailsList = new List<Details>();

            foreach (var item in x)
            {
                var str = JsonConvert.SerializeObject(item);
                var m = (Details)JsonConvert.DeserializeObject<Details>(str);
                detailsList.Add(m);
            }
            var artist = detailsList
                            .Select(d =>
                                    new Artist
                                    {   ImageURL = d.Artist_imageURL,
                                        Title=d.Artist_Title,
                                        Biography=d.Biography,
                                        HeroURL = d.Artist_heroURL 
                                    }).First();
            
            var albums = detailsList
                                .Select(d => 
                                        new MyAlbum
                                         {
                                            Album_Title = d.Album_Title,
                                            Album_imageURL= d.Album_imageURL,
                                            Artist_Title=d.Artist_Title 
                                        }).ToList();

            repeaterItems.DataSource = albums;
            repeaterItems.DataBind();

            songItems.DataSource = data;
            songItems.DataBind();

           
            artistHeroImage.Src = artist.HeroURL;
            artistImageUrl.Src = artist.ImageURL;
            Biography.InnerText = artist.Biography;
            
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}

public class MyAlbum
{
    public string Album_Title { get; set; }
    public string Artist_Title { get; set; }

    public string Album_imageURL { get; set; }
}
public class Details
{
    public string Album_Title { get; set; }

    public string Song_Title { get; set; }

    public string Artist_Title { get; set; }

    public string Bpm { get; set; }

    public string Artist_imageURL { get; set; }

    public string Artist_heroURL { get; set; }

    public string Album_imageURL { get; set; }

    public string Biography { get; set; }
}

public class Artist
{
    public string HeroURL { get; set; }

    public string ImageURL { get; set; }

    public string Biography { get; set; }

    public string Title { get; set; }
}
