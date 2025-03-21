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
   
- Search for docker-compose.yml file.
- Run the command docker-compose up -d. from the directory where the dockercompose file is located.

API Endpoints

A. Authentication <
POST /api/users/login

• Description: Authenticate a user and return a JWT token.
• Request Body:
![Request users](https://github.com/user-attachments/assets/60b68ad2-8af5-469e-9ccb-845002b3ccba)

{
    "email":"Jane@gmail.com",
    "password":"qwerty"

}

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


{
    "Name": "The Batman",
    "IdGenre": 4,
    "IdAgeRating": 3,
    "ReleaseDate": "2022-03-04"

}


• Response

![Response POST](https://github.com/user-attachments/assets/0b673496-9668-4b48-9aaa-7fa2844503d5)


PUT/api/movies

• Description: Updates a movie from list of movies
• Headers: Authorization: Bearer <JWT_TOKEN>
• Request body

![PUT Movies](https://github.com/user-attachments/assets/ac3e6c09-46d0-4fb4-ae31-087cbbc4ef49)

{ 
    "Id": 4,
    "Name": "Aliens: the return",
    "IdGenre": 1,
    "IdAgeRating": 4,
    "ReleaseDate": "1986-07-14"

}

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

{
   "genre":"Western"
}

• Response

![Response POST Genres](https://github.com/user-attachments/assets/99215160-bda2-40d6-b0ef-23eae57f2ea9)


PUT/api/genres

• Description: Updates a genre from the list of genres
• Headers: Authorization: Bearer <JWT_TOKEN>
• Request body

![PUT Genres](https://github.com/user-attachments/assets/6a1e7f88-f06f-4907-9637-6452bb918621)

{
   "id":8,
   "genre":"Drama"
}

• Response

![Response PUT Genres](https://github.com/user-attachments/assets/99215160-bda2-40d6-b0ef-23eae57f2ea9)


DELETE/api/genres/id

• Description: Deletes a genre from the list of genres
• Headers: Authorization: Bearer <JWT_TOKEN>
• Response

![Response DELETE Genres](https://github.com/user-attachments/assets/99215160-bda2-40d6-b0ef-23eae57f2ea9)


D. Movies Rating
GET /api/moviesRating

• Description: Retrieve a list of movie ratings.
• Response

![GET Rating](https://github.com/user-attachments/assets/7de119a5-48d6-460d-b792-a4782e2c12c2)


POST/api/moviesRating

• Description: Add a movie rating to a list of movie ratings.
• Headers: Authorization: Bearer <JWT_TOKEN>
• Request body


![POST Rating](https://github.com/user-attachments/assets/e57aca90-fcf0-46fa-a543-a37010873dc5)

{
   "rating": "R"
}

• Response

![Response POST Rating](https://github.com/user-attachments/assets/99215160-bda2-40d6-b0ef-23eae57f2ea9)


PUT/api/moviesRating

• Description: Updates a movie rating to a list of movie ratings.
• Headers: Authorization: Bearer <JWT_TOKEN>
• Request body

![PUT Rating](https://github.com/user-attachments/assets/ca7e6b8a-06b4-4f28-9fa1-76b09e9ec57b)

{
   "id": 6,
   "rating": "RE"
}

• Response

![Response PUT Rating](https://github.com/user-attachments/assets/99215160-bda2-40d6-b0ef-23eae57f2ea9)


DELETE/api/ moviesRating/id

• Description: Deletes a movie rating to a list of movie ratings.
• Headers: Authorization: Bearer <JWT_TOKEN>
• Response

![Response DELETE Rating](https://github.com/user-attachments/assets/99215160-bda2-40d6-b0ef-23eae57f2ea9)


Testing with Postman

To test the API:
1. Use Postman to send a POST request to /api/users/login to retrieve a JWT token.
2. Use the token in the Authorization header for subsequent requests to secured endpoints
(e.g POST/api/movies).

Example Authorization header:

![Bearer Token](https://github.com/user-attachments/assets/28d03f7c-b870-4f33-a126-ce6be7dd0f27)


--------------------------------------------------------------------------------------------
