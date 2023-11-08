DELETE FROM Employees
WHERE
(DATEDIFF(year, DateOfBirth, GETDATE())-
  CASE
    WHEN(
      (MONTH(DateOfBirth)*100 + DAY(DateOfBirth)) >
      (MONTH(GETDATE())*100 + DAY(GETDATE()))
    ) THEN 1
    ELSE 0
  END) > 70