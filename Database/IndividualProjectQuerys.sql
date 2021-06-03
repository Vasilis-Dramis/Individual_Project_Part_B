select * from Students
select * from Trainers
select * from Assignments
select * from Courses

select Courses.CourseID,Courses.title,Courses.stream,Courses.type,Students.StudentID,Students.firstName,Students.lastName from Students
join CourseStudentRelation on Students.StudentID = CourseStudentRelation.StudentID
join Courses on CourseStudentRelation.CourseID = Courses.CourseID
order by Courses.CourseID

select Courses.CourseID,Courses.title,Courses.stream,Courses.type,Trainers.TrainerID,Trainers.firstName,Trainers.lastName from Trainers
join CourseTrainerRelation on Trainers.TrainerID = CourseTrainerRelation.TrainerID
join Courses on CourseTrainerRelation.CourseID = Courses.CourseID
order by Courses.CourseID

select Courses.CourseID,Courses.title,Courses.stream,Courses.type,Assignments.AssignmentID,Assignments.title,Assignments.description from Assignments
join CourseAssignmentsRelation on Assignments.AssignmentID = CourseAssignmentsRelation.AssignmentID
join Courses on CourseAssignmentsRelation.CourseID = Courses.CourseID
order by Courses.CourseID

--searching for specific course

select Courses.CourseID,Courses.title,Courses.stream,Courses.type,Students.StudentID,Students.firstName,Students.lastName from Students
join CourseStudentRelation on Students.StudentID = CourseStudentRelation.StudentID
join Courses on CourseStudentRelation.CourseID = Courses.CourseID
where Courses.CourseID = 1
order by Students.StudentID

select Courses.CourseID,Courses.title,Courses.stream,Courses.type,Trainers.TrainerID,Trainers.firstName,Trainers.lastName from Trainers
join CourseTrainerRelation on Trainers.TrainerID = CourseTrainerRelation.TrainerID
join Courses on CourseTrainerRelation.CourseID = Courses.CourseID
where Courses.CourseID = 1
order by Trainers.TrainerID

select Courses.CourseID,Courses.title,Courses.stream,Courses.type,Assignments.AssignmentID,Assignments.title,Assignments.description from Assignments
join CourseAssignmentsRelation on Assignments.AssignmentID = CourseAssignmentsRelation.AssignmentID
join Courses on CourseAssignmentsRelation.CourseID = Courses.CourseID
where Courses.CourseID = 1
order by Assignments.AssignmentID

--Students with multiple courses

select * from Students
where exists
(select CourseStudentRelation.StudentID from CourseStudentRelation
where CourseStudentRelation.StudentID = Students.StudentID
group by CourseStudentRelation.StudentID
having count(CourseStudentRelation.CourseID) > 1)

-- assignments per student per course

select Students.StudentID, Students.firstName, Students.lastName,Courses.CourseID, Assignments.AssignmentID, Assignments.title, Assignments.description from Students
join CourseStudentRelation on Students.StudentID = CourseStudentRelation.StudentID
join Courses on CourseStudentRelation.CourseID = Courses.CourseID
join CourseAssignmentsRelation on Courses.CourseID = CourseAssignmentsRelation.CourseID
join Assignments on CourseAssignmentsRelation.AssignmentID = Assignments.AssignmentID
order by Students.StudentID



