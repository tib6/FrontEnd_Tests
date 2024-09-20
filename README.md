Project Overview
This project is a template for setting up automated UI tests using Selenium WebDriver, NUnit as the testing framework, and ExtentReports for generating test reports. The project targets .NET 6.0 and comes preconfigured with essential NuGet packages for UI testing.

Key Features:

NUnit: A popular testing framework for C#.

Selenium WebDriver: A powerful tool for browser automation.

ExtentReports: For creating rich and interactive test reports with screenshots.

Chrome WebDriver: Integrated for Google Chrome browser automation.



Project Structure

The project has a standard structure:

ProjectRoot/

│

├── Hooks/

│   └── Hook.cs          # Set up global hooks for ExtentReports and WebDriver

│

├── PageObject/

│   └── ExemplePage.cs      # Base class for page objects (optional)

│

├── Tests/

│   └── ExempleTests.cs    # Example test class to demonstrate setup

│

├── TestResults/         # Generated test results and screenshots

│

└── appSetting.json  # Url config file

│

└── ProjectNamespace.csproj  # Project configuration file


Configuration

The project file (.csproj) is configured with the necessary NuGet package references:

<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>

    <TargetFramework>net6.0</TargetFramework>
    
    <ImplicitUsings>enable</ImplicitUsings>
    
    <Nullable>enable</Nullable>
    
    <IsPackable>false</IsPackable>
    
    <IsTestProject>true</IsTestProject>
  
  </PropertyGroup>
  
  <ItemGroup>
  
    <PackageReference Include="coverlet.collector" Version="6.0.0" />
    
    <PackageReference Include="ExtentReports" Version="4.1.0" />
    
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
    
    <PackageReference Include="NUnit" Version="3.14.0" />
    
    <PackageReference Include="NUnit.Analyzers" Version="3.9.0" />
    
    <PackageReference Include="NUnit3TestAdapter" Version="4.5.0" />
    
    <PackageReference Include="Selenium.WebDriver" Version="4.24.0" />
    
    <PackageReference Include="Selenium.WebDriver.ChromeDriver" Version="129.0.6668.5800" />
  
  </ItemGroup>

  <ItemGroup>
  
    <Using Include="NUnit.Framework" />
    
  </ItemGroup>

</Project>

Key NuGet Packages:

coverlet.collector: For code coverage data collection.

ExtentReports: To generate detailed test reports.

Microsoft.NET.Test.Sdk: Required to run tests with .NET.

NUnit: Testing framework.

NUnit3TestAdapter: Adapter for running NUnit tests in Visual Studio.

Selenium.WebDriver: For automating browsers.

Selenium.WebDriver.ChromeDriver: ChromeDriver for Selenium.


Writing Your Own Tests

1. Create a new Page Object: Create a new class in the Pages/ folder that represents the web page you want to test.

2. Write Tests: Create test methods in the Tests/ folder that use the page objects to interact with the web elements.

3. Run Tests: Use dotnet test to run your new tests and see results in the ExtentReport.


Conclusion

This template provides a quick start for setting up a Selenium-based automation framework with NUnit and ExtentReports. It is designed to be easily extensible and maintainable, following the Page Object Model for structuring your test code.

Feel free to modify and expand the framework according to your needs!

