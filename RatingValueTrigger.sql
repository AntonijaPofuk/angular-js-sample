  CREATE  OR ALTER TRIGGER RatingControl2    
  ON MovieRating 
  AFTER INSERT, UPDATE 
  AS 
  BEGIN  
    UPDATE Movie SET Rating = (
      Select AVG(Rating) 
      from MovieRating
	  	  WHERE MovieId = (SELECT Id FROM inserted)
	  GROUP BY MovieId
      )
	WHERE Id = (SELECT Id FROM inserted)

	END

