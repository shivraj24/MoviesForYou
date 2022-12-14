# MoviesForYou Application REST API

### Build ASP.NET Core Web API (.NET 6) :
1. Use Entity Framework Core and LINQ.
2. Use Seq tool to view and collect application logs.
3. Implement the Repository and Unit of Work Patterns.
4. Implement the Custom Middlewares and ExceptionHandlers.
5. Microsoft's SQL Server relational database management system
6. Use Swagger to document the API generated by the Swagger specification.

## Get list of Movies

### Request

`GET /api/MoviesForYou/Movies`

    curl -i -H 'Accept: application/json' https://localhost:7093/api/MoviesForYou/Movies

### Response

    HTTP/1.1 200 OK
    content-length: 2017
    content-type: application/json; charset=utf-8
    date: Sat, 10 Dec 2022 10:24:22 GMT
    server: Kestrel

    []

## Create a new Movie

### Request

`POST /api/MoviesForYou/AddMovie`

    curl -i -H 'Accept: application/json' https://localhost:7093/api/MoviesForYou/AddMovie

    Request Payload:
    {
          "movieId": 0,
          "name": "Andrew Schulz",
          "plot": "Comedy",
          "dateOfRelease": "2022-12-10T10:25:46.760Z",
          "producer": {
            "producerId": 2,
            "name": "The Rock",
            "bio": "Rock Solid",
            "dateOfBirth": "2022-12-09T17:11:11.327",
            "company": "Teremauna",
            "gender": 0
          },
          "actors": [
            {
            "actorId": 1,
            "name": "pranav",
            "bio": "string",
            "dateOfBirth": "2022-12-09T14:17:45.721",
            "gender": 0,
            "movies": null
          },
          ]
       }

### Response

    HTTP/1.1 201 Created
    content-length: 394
    content-type: application/json; charset=utf-8
    date: Sat, 10 Dec 2022 10:31:12 GMT
    server: Kestrel

    {
      "content": {
        "movieId": 8,
        "name": "Andrew Schulz",
        "plot": "Comedy",
        "dateOfRelease": "2022-12-10T10:25:46.76Z",
        "producer": {
          "producerId": 2,
          "name": "The Rock",
          "bio": "Rock Solid",
          "dateOfBirth": "2022-12-09T17:11:11.327",
          "company": "Teremauna",
          "gender": 0
        },
        "actors": [
          {
            "actorId": 1,
            "name": "pranav",
            "bio": "string",
            "dateOfBirth": "2022-12-09T14:17:45.721",
            "gender": 0,
            "movies": []
          }
        ]
      },
      "message": "Successfully Added"
    }

## Update a specific Movie

### Request

`PUT /api/MoviesForYou/UpdateMovie`

    curl -i -H 'Accept: application/json' https://localhost:7093/api/MoviesForYou/UpdateMovie

    Request PayLoad:
    {
      "movieId": 8,
      "name": "Andrew Schulz",
      "plot": "DarkComedy",
      "dateOfRelease": "2022-12-10T10:25:46.760Z",
      "producer": {
        "producerId": 2,
        "name": "The Rock",
        "bio": "Rock Solid",
        "dateOfBirth": "2022-12-09T17:11:11.327",
        "company": "Teremauna",
        "gender": 0
      },
      "actors": [
        {
        "actorId": 1,
        "name": "pranav",
        "bio": "string",
        "dateOfBirth": "2022-12-09T14:17:45.721",
        "gender": 0,
        "movies": null
      },
      ]
    }

### Response

    HTTP/1.1 200 OK
    content-length: 400
    content-type: application/json; charset=utf-8
    date: Sat, 10 Dec 2022 10:46:58 GMT
    server: Kestrel

    PayLoad : 

    {
      "content": {
        "movieId": 8,
        "name": "Andrew Schulz",
        "plot": "DarkComedy",
        "dateOfRelease": "2022-12-10T10:25:46.76Z",
        "producer": {
          "producerId": 2,
          "name": "The Rock",
          "bio": "Rock Solid",
          "dateOfBirth": "2022-12-09T17:11:11.327",
          "company": "Teremauna",
          "gender": 0
        },
        "actors": [
          {
            "actorId": 1,
            "name": "pranav",
            "bio": "string",
            "dateOfBirth": "2022-12-09T14:17:45.721",
            "gender": 0,
            "movies": null
          }
        ]
      },
      "message": "Update successfull"
    }
## Get list of Actors

### Request

`GET /api/Actors/actors`

    curl -i -H 'Accept: application/json' https://localhost:7093/api/Actors/actors

### Response

    HTTP/1.1 200 OK
    content-length: 2017
    content-type: application/json; charset=utf-8
    date: Sat, 10 Dec 2022 11:26:07 GMT
    server: Kestrel

    [
        {
        "actorId": 1,
        "name": "John Wick",
        "bio": "string",
        "dateOfBirth": "2022-12-09T14:17:45.721",
        "gender": 0,
        "movies": null
        }
    ]

## Update a Actor

### Request

`POST /api/Actors/updateActor`

    curl -i -H 'Accept: application/json' https://localhost:7093/api/Actors/updateActor

    Request Payload:
    {
        "actorId": 1,
        "name": "John Wick",
        "bio": "string",
        "dateOfBirth": "2022-12-09T14:17:45.721",
        "gender": 0,
        "movies": null
    }

### Response

    HTTP/1.1 201 Created
    content-length: 394
    content-type: application/json; charset=utf-8
    date: Sat, 10 Dec 2022 11:57:17 GMT
    server: Kestrel


## Create a Movie

### Request

`PUT /api/Actors/addActor`

    curl -i -H 'Accept: application/json' https://localhost:7093/api/Actors/addActor


    Request PayLoad:
    {
        "name": "John Wick new",
        "bio": "new antry",
        "dateOfBirth": "2022-12-09T14:17:45.721",
        "gender": 0,
        "movies": null
    }
### Response

    HTTP/1.1 200 OK
    content-length: 400
    content-type: application/json; charset=utf-8
    date: Sat, 10 Dec 2022 10:46:58 GMT
    server: Kestrel


## Get list of Producers

### Request

`GET /api/Producers/producers`

    curl -i -H 'Accept: application/json' https://localhost:7093/api/Producers/producers

### Response

    HTTP/1.1 200 OK
    content-length: 450
    content-type: application/json; charset=utf-8
    date: Sat, 10 Dec 2022 12:04:54 GMT
    server: Kestrel

    [
        {
            "producerId": 1,
            "name": "Atharv",
            "bio": "More",
            "dateOfBirth": "2022-12-09T16:38:18.313",
            "company": "Suits",
            "gender": 0
        }
    ]

## Update a Producer

### Request

`PUT /api/Producers/updateProducer`

    curl -i -H 'Accept: application/json' https://localhost:7093/api/Producers/updateProducer

    Request Payload:
    {
            "producerId": 1,
            "name": "Atharv",
            "bio": "Ross Brothers",
            "dateOfBirth": "2022-12-09T16:38:18.313",
            "company": "Suits",
            "gender": 0
    }

### Response

    HTTP/1.1 200 Ok
    content-length: 394
    content-type: text/plain; charset=utf-8
    date: Sat, 10 Dec 2022 12:06:31 GMT
    server: Kestrel


## Create a Producer

### Request

`POST /api/Producers/addProducer`

    curl -i -H 'Accept: application/json' https://localhost:7093/api/Producers/addProducer

    Request PayLoad:
    {
      "name": "Dona",
      "bio": "Mike",
      "dateOfBirth": "2022-12-10T12:07:56.836Z",
      "company": "Qa",
      "gender": 0
    }
### Response

    HTTP/1.1 201 Created
    content-length: 400
    content-type: text/plain; charset=utf-8
    date: Sat, 10 Dec 2022 12:08:23 GMT
    server: Kestrel

## Application Logs:

### Logs : 
   ![Screenshot](SeqLogs.png)
## Running Seq application on local docker container:
   ![Screenshot](Docker.png)
