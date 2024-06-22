SELECT *
FROM tblUserProfile

SELECT *
FROM tblSystemUsers

SELECT *
FROM tblSpecialties

SELECT *
FROM tblSchedule

SELECT *
FROM tblDaysWeek

SELECT *
FROM tblOffces

----------------------------------------------------------------

SELECT up.IdSUserProfile, 
       up.UserProfile,
       su.SitSystemUsers,  
       su.SystemUsers,
       su.SystemUsersPass,
       su.SitSystemUsers
FROM tblUserProfile up
INNER JOIN tblSystemUsers su
ON up.IdSUserProfile = su.IdSUserProfile