# Laszlo Sandbox project for BE course.

name | value
--- | ---
language | C#
database | Postgres
deployed | [Heroku](https://asp-net-sandbox1.herokuapp.com/)

# Images of running application

Swagger:

![image](https://user-images.githubusercontent.com/79322093/134395010-c9fe5d22-7132-4afb-8a8a-961febadb0c5.png)

Application:

![image](https://user-images.githubusercontent.com/79322093/134395057-c498c7c1-c112-4a6a-b977-03f096786eb3.png)

## How to run in Docker from the commandline

Navigate to [AspNetSandbox](AspNetSandbox) directory

Build in container
```
docker build -t web_laszlo .
```

to run

```
docker run -d -p 8081:80 --name web_container_laszlo web_laszlo
```

to stop container
```
docker stop web_container_laszlo
```

to remove container
```
docker rm web_container_laszlo
```

## Deploy to heroku

1. Create heroku account
2. Create application
3. Make sure application works locally in Docker


Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a asp-net-sandbox1 web
```

Release the container
```
heroku container:release -a asp-net-sandbox1 web
```
