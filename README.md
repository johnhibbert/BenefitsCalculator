# BenefitsCalculator

# Project Descriptions

BenefitsBlazor: This is the actual working UI project, written in Blazor.  It should let you calculate these values as you wish on the fly.  To consume my code in a web browser, set this as your startup project.

BenefitsCalculator: This is the project that contains the actual classes that conduct the calculations as described, and are consumed by the other projects.

BenefitsCalculator.Tests: A unit test project, containing a small number of rudimentary unit tests.

BenefitsConsole: A console application that also consumes the BenefitsCalculator.  I quickly wrote this at a point where I wasn't sure I was going to be able to get a UI to work (See the story behind BenefitsUI for more on that).  It was also a quick sanity check to be sure I still thought it was okay.  You can use this by setting it as your startup project, and the instructions should be self-explanatory.

BenefitsUI: This is a half-working project that I left in here for posterity.  It should compile and display something, but it is not dynamic.  You can change it in the controller methods.  For background, I don't work in the UI too much in my recent work, so I knew I had to research.  The problem happened because I thought Ineeded to research MVC and Razor, but was unable to understand the JavaScript binding from the examples I could find.  That night I realized that I was actually thinking of Blazor specifically, which would allow me to directly just bind to a C# model using the Razor syntax.  The result of that was the BenefitsBlazor project.
