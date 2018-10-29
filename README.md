# Football_Exercise


The solution is a 3 tier Architecture:

Data Access Layer- DAL and its interface IDAL  - This layer is responsible for Reading raw Data from file

Business Layer or Service Layer- This layer validates the Data structure(Validates the columnnames and number of columns by raising custom exceptions that 
are handled), also converts raw data into meaningful data and returns it to the viewmodel.

UI layer is WPF arctuitecture with MVVM pattern. Teams having minimum difference are displayed in a grid as there can be more than one..

Architecture uses depedency injection and loose coupling
Busines layer is only dependent upon data Access layer interface
MockIOC container is implemented in the wpf application which creates concrete layer instances and supplies dependencies via constructor injection.

Solution also illustrates TDD architecture. and Unit tests are created for Data access layer and Business layer.
Unit test for Business layer use Moq to mock any calls to data accesslayer, so that the layers acn be developed and tested independent of each other.

App.config is used in both Test projects and the WPF application so that users can specify the location of datasource and logfile and change it at will.

For simplicity Custom logging is used, and data retrieval ishappening on UI thread only.
It could easily enhanced to fetch data on background thread and use log4.net for a more professional application.
