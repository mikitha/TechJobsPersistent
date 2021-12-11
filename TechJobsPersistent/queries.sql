--Part 1
describe jobs
--Part 2
select * from employers where Location = "St. Louis"
--Part 3
select distinct Name, Description from skills s 
left join jobskills j 
on j.skillid = s.Id 
order by name
