Feature: AddCourses
	In order to add courses
	As a university administrator
	I want to be shown a sequential list of courses

Scenario: Add Courses to College
	Given I am adding courses to a college	
	Then the courseList list should display schedule
	| courseList                                                                                                                                                                                                                                                                                          | schedule                                                                                                                                                               |
	| Introduction to Paper Airplanes:,Advanced Throwing Techniques: Introduction to Paper Airplanes,History of Cubicle Siege Engines: Rubber Band Catapults 101,Advanced Office Warfare: History of Cubicle Siege Engines,Rubber Band Catapults 101: ,Paper Jet Engines: Introduction to Paper Airplanes | Introduction to Paper Airplanes, Advanced Throwing Techniques, Paper Jet Engines, Rubber Band Catapults 101, History of Cubicle Siege Engines, Advanced Office Warfare |
	| Intro to Arguing on the Internet: Godwin’s Law, Understanding Circular Logic: Intro to Arguing on the Internet, Godwin’s Law: Understanding Circular Logic                                                                                                                                          | 'Understanding Circular Logic' has a prerequisite course with a cirular reference.                                                                                     |