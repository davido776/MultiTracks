using DataAccess;
using System;
using System.Collections.Generic;

public partial class Default : MultitracksPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var sql = new SQL();

        try
        {
            //sql.Parameters.Add("@stepID", 1);
            var data = sql.ExecuteStoredProcedureDT("GetAssessmentSteps");
            var x = DataTableExtensions.ToDynamic(data);
           
            //var y = DB.Write<>(data,1);
            

            assessmentItems.DataSource = data;
            assessmentItems.DataBind();

            publishDB.Visible = false;
            items.Visible = true;
        }
        catch 
        {
            publishDB.Visible = true;
            items.Visible = false;
        }
    }
}


