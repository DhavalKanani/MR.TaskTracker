// Use DBML to define your database structure
// Docs: https://dbml.dbdiagram.io/docs

Table ApplicationUsers {
Id integer [primary key]
FirstName varchar
LastName varchar
UserName varchar
Email varchar
Role varchar
Password varchar
DateCreated timestamp
DateModified timestamp
ReportsToId integer
}

table TaskAssignments{
Id integer [primary key]
DateCreated timestamp
DateModified timestamp
Title varchar
Description varchar
CurrentStatus varchar
StoryPoint decimal
DueDate datetimeoffset
AssigneeId int
ReporterId int
}

table TaskAttachments{
Id integer [primary key]
DateCreated timestamp
DateModified timestamp
FileName varchar
Length inet6
Content blob
TaskAssignmentId int
ById int
}

table TaskComments{
Id integer [primary key]
DateCreated timestamp
DateModified timestamp
Comment varchar
TaskAssignmentId int
ById int
}

table TaskActions{
Id integer [primary key]
DateCreated timestamp
DateModified timestamp
FromStatus varchar
ToStatus varchar
TaskAssignmentId int
}

Ref: ApplicationUsers.ReportsToId > ApplicationUsers.Id
Ref: TaskAssignments.AssigneeId > ApplicationUsers.Id
Ref: TaskAssignments.ReporterId > ApplicationUsers.Id
Ref: TaskAttachments.ById > ApplicationUsers.Id
Ref: TaskAttachments.TaskAssignmentId > TaskAssignments.Id
Ref: TaskComments.ById > ApplicationUsers.Id
Ref: TaskComments.TaskAssignmentId > TaskAssignments.Id
Ref: TaskActions.TaskAssignmentId > TaskAssignments.Id
