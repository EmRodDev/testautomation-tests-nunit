<a name="readme-top"></a>

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <img src="https://www.svgrepo.com/show/354321/selenium.svg" alt="Logo" width="80" height="80">
  <h3 align="center">TestAutomation-Tests</h3>
  
  <p align="center">
    A basic set of test suites for C#
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
        <li><a href="#configuration">Configuration</a></li>
      </ul>
    </li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project


This is a project I did on an Udemy course about NUnit, Selenium WebDriver and C#. 

* Although it's based on the project seen on said course, I did some improvements on the code and some corrections on the conventions used on it. 

* It has:
  * The fundamentals of a professional project with said technologies used on companies.

  * A POP (Page Object Pattern) structure set of tests

  * A configuration file which eases the process of setting up and configuring the project

  * Parallelized tests

The structure of the folders is the following:

* **Start**: The beggining of this project. It has the fundamental things you need to know on how to make a basic test.
* **Frames**: A test on how to switch between HTML iframes.
* **Selectors**: A test of various selectors used on tests.
* **PageObjectPattern**: A test suite of a basic fruit e-commerce. Said test suite is based on various excercises used on some company exams, using models, helpers, factories, etc.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

* [![C#][C#-Badge]][C#-Url]
* [![Selenium][Selenium-Badge]][Selenium-Url]
* [![Visual Studio][VStudio-Badge]][VStudio-Url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

### Prerequisites

* Visual Studio
  * .NET desktop development workload

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/EmRodDev/testautomation-tests-nunit
   ```

2. Open the project in Visual Studio

3. Build the solution

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Configuration
There is an *appsettings.json* configuration file inside the root folder of the project. This file only affects the tests inside the *PageObjectPattern* folder or the *FreshMarketTest* visible on the Test Explorer.

Said file comes with some parameters you can change to your liking, which are the following:
* **Browser:** The browser used on the tests. The supported options here are *Chrome*, *Edge* or *Firefox*. Any other option will throw an error.

* **WaitTimeout:** The time in seconds of the driver trying to find an element with a selector before it fails the test.

* **Headless:** A boolean parameter which indicates the driver to execute in headless mode or not.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTACT -->
## Contact
[![LinkedIn][Linkedin-Badge]][Linkedin-Url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>




<!-- MARKDOWN LINKS & IMAGES -->
<!--Badges-->
[C#-Badge]:https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white
[Selenium-Badge]:https://img.shields.io/badge/Selenium-43B02A?logo=selenium&logoColor=fff&style=for-the-badge
[VStudio-Badge]:https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white
[LinkedIn-Badge]:https://img.shields.io/badge/linkedin-%230077B5.svg?style=for-the-badge&logo=linkedin&logoColor=white

<!--URLs-->
[C#-Url]:https://dotnet.microsoft.com/es-es/languages/csharp
[Selenium-Url]:https://www.selenium.dev/
[VStudio-Url]:https://visualstudio.microsoft.com/
[Linkedin-Url]:https://www.linkedin.com/in/erodriguezarr/
