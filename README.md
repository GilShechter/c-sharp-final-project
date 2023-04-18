# Online Testing System

![Logo](images/logo.png)

This is a project that implements an online testing system, designed for two types of users: teachers and examinees. The system allows teachers to create and manage exams, while examinees can take exams online.

## Features

- Teachers can:
  - Add new exams
  - Edit existing exams
  - View statistics of exam results

- Examinees can:
  - Choose an exam from a list of available exams
  - Answer multiple-choice questions in the exam

- Exams are composed of multiple-choice questions, similar to American exams, with no limit on the number of answers per question
- Questions can be presented as text or as images, and each question carries the same point value

## Technologies Used

- Client-side: C# WPF
- Server-side: .NET ASP and Entity Framework for creating an API to facilitate communication between the client and server components of the system

## NuGet Packages Used

The following NuGet packages are used in this project:

- Microsoft.EntityFrameworkCore.Core: Used for Entity Framework Core, which is an ORM (Object-Relational Mapping) for working with databases in .NET applications.
- Microsoft.AspNet.WebApi.Client: Used for building HTTP clients in ASP.NET Web API applications, which allows communication with remote APIs.
- Newtonsoft.Json: Used for JSON serialization and deserialization in .NET applications.


## Installation

To set up the online testing system locally, follow these steps:

1. Clone the repository to your local machine.
2. Set up the client-side using WPF technology.
3. Set up the server-side using .NET ASP and Entity Framework to create the API.
4. Restore the NuGet packages using the package manager or the `dotnet restore` command.
5. Run the system locally for testing and development purposes.

## Video Presentation

Watch our video presentation [here](https://www.canva.com/design/DAFgKm1g8RQ/9LbXa_dqdQlLAEOO3bs5dA/watch) to learn more about the online testing system.

## Contribution

Contributions to this project are welcome. If you would like to contribute, please open an issue or submit a pull request. Let's make the online testing system better together!

