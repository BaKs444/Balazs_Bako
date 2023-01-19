# Balazs_Bako



This projects aim to test the OrangeHRM Webpage with test automation tools. The project Created with .NET and has a folder based structure. The project uses the Page Object model, and contains both the TestFramework and the Tests too. While running it is enter to the webpage with "Admin" credentials and add a new record to PayGrades. Then it checks that the record was added and after the scenario it deletes the just created record. The project contains 2 tests. It contains Allure test reporter. Read further to get instructions how to use it. 

To use the Allure test reporter Download and install the Allure Framework from this site: https://docs.qameta.io/allure/#_installing_a_commandline . Then add it to the system variables. If you done it, íou cna open the test results from cmd. The results jsons are created here:WebUI\WebUI\bin\Debug\net6.0. Open the cmd from here and run the following command: "allure serve allure-results". The results are shown in the default web browser.
