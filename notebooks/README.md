# Info

This folder contains C# notebooks for testing the functionality of the ClashOfClans library. The main purpose for these notebooks is to allow anyone to try the ClashOfClans library and its functionality without having own local development environment!

You can try the interactive notebooks by clicking the [![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/tparviainen/clashofclans/develop?urlpath=lab) which creates an executable environment available via web browser. After the environment is built open `00-README.ipynb` notebook and follow the instructions to setup API token etc.

# Local

If you already have Docker in your local development environment you can build the Docker image locally and start it by giving the next command in the `notebooks` folder:

```
docker-compose up --build
```

After the image is running the output contains the URL to open in a browser:

```
notebooks-clashofclans-1  |     Or copy and paste one of these URLs:
notebooks-clashofclans-1  |      or http://127.0.0.1:8888/?token=bc092f54d4218e10f16ad27609c60742b9a51193bb6de4cd
```
