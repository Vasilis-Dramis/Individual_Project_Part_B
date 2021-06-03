truncate table CourseStudentRelation
truncate table CourseTrainerRelation
truncate table CourseAssignmentsRelation

alter table CourseStudentRelation
drop constraint FK_CourseStudentRelation_Courses;
alter table CourseStudentRelation
drop constraint FK_CourseStudentRelation_Students;

truncate table Students

alter table CourseTrainerRelation
drop constraint FK_CourseTrainerRelation_Courses;
alter table CourseTrainerRelation
drop constraint FK_CourseTrainerRelation_Trainers;

truncate table Trainers

alter table CourseAssignmentsRelation
drop constraint FK_CourseAssignmentsRelation_Courses;
alter table CourseAssignmentsRelation
drop constraint FK_CourseAssignmentsRelation_Assignments;

truncate table Assignments

truncate table Courses

alter table CourseStudentRelation add constraint FK_CourseStudentRelation_Courses foreign key(CourseID) references Courses (CourseID);
alter table CourseStudentRelation add constraint FK_CourseStudentRelation_Students foreign key(StudentID) references Students (StudentID);

alter table CourseTrainerRelation add constraint FK_CourseTrainerRelation_Courses foreign key(CourseID) references Courses (CourseID);
alter table CourseTrainerRelation add constraint FK_CourseTrainerRelation_Trainers foreign key(TrainerID) references Trainers (TrainerID);

alter table CourseAssignmentsRelation add constraint FK_CourseAssignmentsRelation_Courses foreign key(CourseID) references Courses (CourseID);
alter table CourseAssignmentsRelation add constraint FK_CourseAssignmentsRelation_Assignments foreign key(AssignmentID) references Assignments (AssignmentID);
