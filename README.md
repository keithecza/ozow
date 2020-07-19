# Ozow Assessment

## Approach
This section describes the approach taken for the solution. The approach described here does not need to be taken for all projects in all companies.
* The unit of the Unit tests is the method, whether public or private. A unit test is a whitebox text and as such knows and tests the implementation details of the unit. If these change the unit test should break.
* A class should be mocked if 1) It is an external dependency and 2) It is not under the program's control. Did not mock all classes only those that satisfy these conditions or if the conditions were not satisfied but mocking would simplify the testing. Some people discourage too much mocking (See Common Pitfalls at https://www.agilealliance.org/glossary/mocks#q=~(infinite~false~filters~(postType~(~'page~'post~'aa_book~'aa_event_session~'aa_experience_report~'aa_glossary~'aa_research_paper~'aa_video)~tags~(~'mock*20objects))~searchTerm~'~sort~false~sortDirection~'asc~page~1) )
* The unit test is named after the method tested. If more than one method is required for the test then the name is postfixed with a number. The Description attribute is used to describe what is being tested, not the test method name.

## Enhancements
The following enhancements can be made to the GameOfLife.View
* Allow the game to be stopped. 
* Do not allow interaction when the game is running.
* Unit test the GameOfLife.View.
* Split the GameOfLife.View into a View and a ViewModel.

## Using GameOfLife.View

<img src="https://github.com/keithecza/ozow/blob/master/GameOfLife.View.png" width="750" height="750" />

Specify With, Height and Generations. Left-click the cells to toggle their initial existence state. Alternatively, load an existing board using the dropdown. Click Run to start.
