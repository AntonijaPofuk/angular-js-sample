--====================================
--  Create database trigger template 
--====================================
USE AngularJsSample
GO

CREATE OR ALTER TRIGGER RatingControl  
ON Movie
AFTER INSERT, UPDATE AS BEGIN

UPDATE Movie 
SET 
Movie.Rating = (SELECT(SUM(i.Rating+MovieRating.Rating))/2
FROM MovieRating 
INNER JOIN inserted i 
ON MovieRating.MovieId = i.Id
GROUP BY MovieRating.MovieId
)
FROM inserted i
WHERE Movie.Id = i.Id


END
GO



      

