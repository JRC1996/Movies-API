# Movies - api

API Documentation: Movies API with JWT Authentication and
Docker Compose.
Overview
The Movies API provides CRUD functionality for managing movies and allows users to
authenticate using JWT Bearer Tokens. The API is containerized using Docker and Docker
Compose to streamline deployment and ensure that the application runs in a consistent
environment.

Technologies Used

• .NET Core 8.0
• Entity Framework Core (EF Core) Database-First
• SQL Server
• JWT Bearer Authentication
• Docker and Docker Compose

Prerequisites
To run this project locally, you will need:

• Docker and Docker Compose.
• Postman or another API testing tool (for testing API endpoints)

Getting Started
A. Docker Compose Setup
The docker-compose.yml file orchestrates the API and the SQL Server database.
![Dockerfile](https://github.com/user-attachments/assets/8a878134-2cdc-4e92-a627-0fd149d6de38)

B. Running the Application

Docker
1. To run the project in docker:
   
o Search for docker-compose.yml file.
o Run the command docker-compose up -d. from the directory where the dockercompose file is located.

API Endpoints

A. Authentication <
POST /api/users/login

• Description: Authenticate a user and return a JWT token.
• Request Body:
![Request users](https://github.com/user-attachments/assets/60b68ad2-8af5-469e-9ccb-845002b3ccba)

• Response:
![Response users](https://github.com/user-attachments/assets/76d86064-bb6f-40f0-a2a5-b154c73b9670)


B. Movies
GET /api/movies

• Description: Retrieve a list of movies
• Response

![GET Movies](https://github.com/user-attachments/assets/0cc84620-4ea0-46da-a66d-57a90cbf5a1b)


POST/api/movies

• Description: Add a movie to list of movies
• Headers: Authorization: Bearer <JWT_TOKEN>
• Request body

![POST Movies](https://github.com/user-attachments/assets/a09c0419-d9d8-44b1-8b2d-83d8bc30df20)

• Response

![Response POST](https://github.com/user-attachments/assets/0b673496-9668-4b48-9aaa-7fa2844503d5)


PUT/api/movies

• Description: Updates a movie from list of movies
• Headers: Authorization: Bearer <JWT_TOKEN>
• Request body

![PUT Movies](https://github.com/user-attachments/assets/ac3e6c09-46d0-4fb4-ae31-087cbbc4ef49)

• Response

![Response PUT](https://github.com/user-attachments/assets/4ef630d5-a429-49ec-9b08-e3a8ae8f29e2)


DELETE/api/movies/id

• Description: Deletes a movie from the list of movies
• Headers: Authorization: Bearer <JWT_TOKEN>
• Response

![Response DELETE](https://github.com/user-attachments/assets/e3a01666-40f1-4d30-a194-ed86e164d233)


C. Genres
GET /api/genres

• Description: Retrieve a list of genres
• Response

![GET Genres](https://github.com/user-attachments/assets/7a9af90c-b150-4346-87a1-f657588bb6d8)


POST/api/genres

• Description: Add a genre to list of genres
• Headers: Authorization: Bearer <JWT_TOKEN>
• Request body

![POST Genres](https://github.com/user-attachments/assets/68787850-d328-4a26-a2e0-d1c7421a12da)

• Response

![Response POST Genres](https://github.com/user-attachments/assets/99215160-bda2-40d6-b0ef-23eae57f2ea9)


PUT/api/genres

• Description: Updates a genre from the list of genres
• Headers: Authorization: Bearer <JWT_TOKEN>
• Request body

![PUT Genres](https://github.com/user-attachments/assets/6a1e7f88-f06f-4907-9637-6452bb918621)

• Response

![Response PUT Genres](https://github.com/user-attachments/assets/99215160-bda2-40d6-b0ef-23eae57f2ea9)


DELETE/api/genres/id

• Description: Deletes a genre from the list of genres
• Headers: Authorization: Bearer <JWT_TOKEN>
• Response

![Response DELETE Genres](https://github.com/user-attachments/assets/99215160-bda2-40d6-b0ef-23eae57f2ea9)



--------------------------------------------------------------------------------------------
