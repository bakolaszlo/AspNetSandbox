﻿# Laszlo Sandbox project for BE course.

name | value
--- | ---
language | C#
database | Postgres
deployed | [link](https://asp-net-sandbox1.herokuapp.com/ "Heroku")

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