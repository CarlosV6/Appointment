SELECT *
FROM tblUserProfile

UPDATE tblUserProfile
SET    UserProfile = ''
WHERE  NOT IdSUserProfile IN (1,2,3)
AND    IdSUserProfile = 4

DELETE tblUserProfile
WHERE  NOT IdSUserProfile IN (1,2,3)
AND    IdSUserProfile = 4
-------------------------------------------------------------------------------------
SELECT *
FROM tblSystemUsers

UPDATE tblSystemUsers
SET    IdSUserProfile = 0,
       SystemUsers = '',
       SystemUsersPass = '',
       SitSystemUsers = 0
WHERE  IdSystemUsers = 4

DELETE tblSystemUsers
WHERE  IdSystemUsers = 4
-------------------------------------------------------------------------------------
SELECT up.IdSUserProfile, 
       up.UserProfile, 
	   su.IdSystemUsers,
       su.SystemUsers,
       su.SystemUsersPass,
       su.SitSystemUsers
FROM tblUserProfile up
INNER JOIN tblSystemUsers su
ON up.IdSUserProfile = su.IdSUserProfile
-------------------------------------------------------------------------------------

SELECT *
FROM tblSpecialties

SELECT *
FROM tblSchedule

SELECT *
FROM tblDaysWeek

SELECT *
FROM tblOffces

----------------------------------------------------------------


