# Mars-Rover
This is a Code Test to display my skills and knowledge about code architecture and practices.

# Objectives
Display knowledge on building clean code architectures, display logic skills and sense of order.

# Dependencies
I did not used anything besides .Net Core, I wanted to display my skills in the purest form possible

# SOLID Principles
This project was made with SOLID principles in mind.

# Clean Code Architecture
The schema made by Uncle Bob displayed here https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html was used as a guide to build this application

# Getting Started
To run this project, open the solution using visual studio, right click on project MarsRover and click on Set as Startup Project

A prompt should open, here you will be asked to set initial boundaries, here we shall give a 2 characters string containing integers or it will throw an exception.

Input Example: 55

Next, we need to type an initial position for our Rover, we will need to introduce a 3 characters string, the first 2 are the position inside the boundarie we set.

We cannot deploy a Rover outside the boundaries, so we need to type 2 integers inside the gived range, then, we need to set up the facing position, wich will be determined
by the following characters:

N is for "North"
S is for "South"
W is for "West"
E is for "East"

Input Example : 12N

At last, we will be prompted to enter instructions for Rover, each instruction is represented by the following characters:

L is for "Turn Left"
R is for "Turn Right"
M is for "Move"

If we try to move outside the boundaries we will get an error.

Input Example: LMLMLMLMM

At last, we will get a response with our current Position, 

Output Example: 13N


