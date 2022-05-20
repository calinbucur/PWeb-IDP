
# Petaway

Petaway is a web platform aiming to help animals stuck in the Ukraine conflict.

![petaway](res/logo.png)

# Project team

PWEB
* Calin-Andrei BUCUR 342C4
* Catalin-Mihail CHIRU 342C4
  
IDP
* Carapcea Andrei-Antonio 342C1
* Rusu Bianca-Ana-Maria 342C2




# Architecture

![architecture](res/architecture.png)

# Backend Architecture

![backend_architecture](res/backend_architecture.png)

# Tactical Domain Driven Design

![tddd](res/backend_architecture.png)


# Running instructions

You can run a setup script with:

```
npm run setup
```

This will install all dependencies (eg. `node_modules`) for the subprojects.

You can start all dependency components (postgres, rabbitmq, pgadmin) with:
```
npm run deps
```

You can run a single component, for example the backend with:
```
npm run dev:api
```
Or the frontend with:
```
npm run dev:frontend
```

You can build a docker image for each component, for example:

```
npm run docker:mail:build
```
You can also build all the docker images with:
```
npm run docker:all:build
```

# CI/CD

There are 3 Github Actions pipelines:
- one which works on all branches and builds each app (api, frontend, mailservice), runs linter and tests
- one which works automatically on main, does the same as above, then builds and pushes the docker images and finally it deploys the new stack via a webhook
- a deployment pipeline, which works the same as above but can be run on demand on any branch

The swarm runs Portainer, which uses a git-managed stack. It exposes a webhook which automatically pulls changes from git and re-deploys
the stack if needed.

# Deployment

## Infrastructure

The application was deployed on a swarm on Azure, available at: petaway.northeurope.cloudapp.azure.com.

We also use a private Docker registry hosted on Azure at: idpreg.azurecr.io.

# Useful links

- frontend: https://petaway.northeurope.cloudapp.azure.com:8080/
- backend: http://petaway.northeurope.cloudapp.azure.com:8001/api
- pgadmin: http://petaway.northeurope.cloudapp.azure.com:5050
- prometheus: http://petaway.northeurope.cloudapp.azure.com:9090/graph
- graphana: http://petaway.northeurope.cloudapp.azure.com:9090/graph
