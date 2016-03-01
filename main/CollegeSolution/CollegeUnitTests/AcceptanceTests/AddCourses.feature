Feature: AddCourses
	In order to add courses
	As a university administrator
	I want to be shown a sequential list of courses

Scenario: Add Courses to College
	Given I have added values to the college
	| values                                         |
	| Course A,Course B: Course A                    |
	| Course A,Course B: Course A,Course C: Course B |
	
	When I press add
	Then the result courses should be displayed
	| courses                      |
	| Course A, Course B           |
	| Course A, Course B, Course C |