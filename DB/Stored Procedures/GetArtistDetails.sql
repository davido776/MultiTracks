CREATE PROCEDURE dbo.GetArtistDetails
	@artistID int = 0

AS
BEGIN
	SELECT Artist.title as artist_title, Song.title as song_title, Album.title as album_title,Album.imageURL as album_imageURL,Artist.imageURL as artist_imageURL,Artist.heroURL as artist_heroURL,bpm,biography
	FROM Artist 
	JOIN Song ON Artist.artistID = Song.artistID 
	JOIN Album ON Album.albumID = Song.albumID
	WHERE Artist.artistID = @artistID
	ORDER By Song.dateCreation DESC;
END
