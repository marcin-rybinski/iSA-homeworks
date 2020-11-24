SELECT s.Studio_ID, s.StudioName, count(s.StudioName) as [Number of Employees] 
FROM barber.Employee e
JOIN barber.Studio s
ON e.Studio_ID = s.Studio_ID
GROUP BY s.StudioName, s.Studio_ID

SELECT e.FullName, COUNT(v.Employee_ID) AS [Number of Visits]
FROM barber.Visit v
JOIN barber.Employee e
ON v.Employee_ID = e.Employee_ID
GROUP BY e.FullName

SELECT t.TreatmentName, COUNT(v.Treatment_ID) AS [Number of Visits]
FROM barber.VisitDetail v
JOIN barber.Treatment t
ON v.Treatment_ID = t.Treatment_ID
GROUP BY t.TreatmentName

SELECT s.StudioName, sum(d.TotalCost)
FROM barber.Studio s
JOIN barber.Visit v ON v.Studio_ID = s.Studio_ID
JOIN barber.VisitDetail d ON d.Visit_ID = v.Visit_ID
WHERE d.Visit_ID = v.Visit_ID AND v.Studio_ID = s.Studio_ID
GROUP BY s.StudioName

SELECT TreatmentName
FROM barber.Treatment
WHERE Treatment_ID NOT IN
(
    SELECT Treatment_ID
	FROM barber.VisitDetail
) 

SELECT TOP 1 [Time], COUNT(*) AS [Number of visits]
FROM barber.Visit
GROUP BY [Time]
ORDER BY [Number of visits] DESC
