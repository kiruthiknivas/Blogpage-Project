# Blogpage-Project

## Description

Blogpage-Project is a comprehensive web application built using ASP.NET Core and Entity Framework Core. It provides a platform for users to create, edit, and manage blog posts, as well as comment on them. The application features role-based authentication and authorization using JWT (JSON Web Tokens), ensuring secure access to different functionalities based on user roles.

## Features

- **User Registration and Login**: Users can register and log in to the application. Blog writers have additional privileges to create and manage blog posts.
- **JWT Authentication**: Secure authentication using JWT tokens. Users receive a token upon successful login, which is used to access protected endpoints.
- **Blog Management**: Blog writers can create, edit, and delete blog posts. All users can view blog posts and comments.
- **Commenting System**: Users can add comments to blog posts, fostering interaction and discussion.
- **Swagger Integration**: API documentation and testing are facilitated through Swagger UI, allowing users to authorize and test endpoints directly from the browser.

## Technologies Used

- **ASP.NET Core**: The main framework for building the web application.
- **Entity Framework Core**: ORM for database interactions.
- **JWT**: JSON Web Tokens for secure authentication.
- **Swagger**: API documentation and testing.
- **SQL Server**: Database management system.

## Getting Started

1. **Clone the repository**:
   ```bash
   git clone https://github.com/kiruthiknivas/Blogpage-Project.git
   ```
2. **Navigate to the project directory:**:
   ```bash
   cd Blogpage-Project
   ```
4. **Restore dependencies**:
   ```bash
   dotnet restore
   ```
5. **Update the database connection string in appsettings.json**
6. **Run the application:**
   ```bash
   dotnet run
   ```
7. **Access Swagger UI:**
   Navigate to https://localhost:7124/swagger/index.html to test the API endpoints.
   

