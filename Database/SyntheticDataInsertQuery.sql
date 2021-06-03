insert into Courses (title,stream,type,start_date,end_date)
values ('CB11', 'C#', 'online', '2020/9/16', '2021/3/16'),
	   ('CB11', 'C#', 'parttime', '2020/9/16', '2021/3/16'),
	   ('CB10', 'Python', 'online', '2020/3/5', '2020/10/5'),
	   ('CB10', 'Python', 'parttime', '2020/3/5', '2020/10/5'),
	   ('CB12', 'C#', 'online', '2021/3/16', '2021/9/16'),
	   ('CB10', 'JavaScript', 'online', '2020/3/5', '2020/9/5'),
	   ('CB12', 'Python', 'online', '2021/3/16', '2021/9/16'),
	   ('CB12', 'JavaScript', 'parttime', '2021/3/16', '2021/9/16')

insert into Trainers (firstName, lastName, subject)
values ('Michalis', 'Chamilos', 'Academic Associate'),
		('George', 'Pasparakis', 'Academic Lead'),
		('Aliki', 'Tsirozidi', 'Academic Assistant'),
		('Ektoras', 'Gkatsos', 'Trainer'),
		('Nick', 'Osborn', 'Lead Instructor'),
		('Bill', 'Adriano', 'Instructor')

insert into Students (firstName, lastName, dateOfBirth, tuitionFees)
values ('George', 'Malandris', '1988/6/6', 1800),
('Tatiana', 'Tsitsani', '1991/8/14', 2000),
('John', 'Rizos', '1998/2/23', 1500.50),
('George', 'Tilkens', '1973/2/18', 1800.50),
('Michael', 'Nickolson', '1995/8/23', 1300),
('Melany', 'Sharlow', '1991/4/23', 1900.80),
('Bill', 'Adriano', '1989/08/15', 1500),
('Helen', 'Ferreira', '2000/12/01', 1610.50),
('Christine', 'Pattison', '1982/4/20', 1500.50),
('Bill', 'Osborn', '1990/2/05', 2000.50);

insert into Assignments (title,description,subDateTime,oralMark,totalMark)
values ('IndividualProject', 'Project', '2020/9/22', 50, 100),
		('TeamProject', 'Project', '2020/12/11', 50, 100),
		('Exercise 1', 'Assignment', '2020/12/16', 50, 100),
		('Exercise 2', 'Assignment', '2021/01/01', 50, 100),
		('IndividualProject', 'Project', '2021/02/16', 50, 100),
		('TeamProject', 'Project', '2021/02/16', 50, 100),
		('Exercise 3', 'Assignment', '2020/11/18', 50, 100),
		('Exercise 4', 'Assignment', '2021/02/18', 50, 100),
		('Exercise 5', 'Assignment', '2021/05/18', 50, 100)

insert into CourseStudentRelation(CourseID,StudentID)
values (1, 1),(1, 2),(1, 3),(1, 4),(1, 5),(1, 6),(1, 7),(1, 8),(1, 9),(1, 10),(2, 2),(3, 1),(3, 2),
(4, 7),(5, 1),(5, 10),(6, 1),(6, 2),(6, 7),(8, 1),(8, 4),(8, 8)

insert into CourseTrainerRelation(CourseID,TrainerID)
values (1, 1),(2, 1),(2, 2),(3, 1),(3, 2),(3, 3),(3, 4),(3, 5),(3, 6),(5, 1),(5, 5),(5, 6),(6, 3),(6, 4),(8, 3)

insert into CourseAssignmentsRelation(CourseID,AssignmentID)
values (1, 1),(1, 3),(2, 2),(4, 3),(5, 7),(5, 9),(6, 4),(6, 5),(6, 7),(6, 8),
(8, 1),(8, 2),(8, 3),(8, 4),(8, 5),(8, 6),(8, 7),(8, 8),(8, 9)
