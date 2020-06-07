# Bitcoin Application

The application is a web platform that fetches <strong>Bitcoin price (BTC/USD)</strong> from multiple sources and presents them to the user. 
It consumes 2 BTC/USD price sources:

* Bitstamp: https://www.bitstamp.net/api/ticker/
* GDAX: https://api.gdax.com/products/BTC-USD/ticker 

This application is a simple startup project using <strong>ASP.NET Core 3.0</strong> for backend implementatin and <strong>Angular 8</strong> for frontend implementation.

# Architecture

<p>The technologies used are <strong>Angular 8</strong> for the client and <strong>.Net Core 3.0/Sql Server</strong> for the server.</p>
<p>The architecture is mainly based on <strong>repository pattern</strong>, and the data are retrieved by <strong>Entity Framework Core</strong>.</p>
<p>The server uses <strong>Json Web Tokens</strong> for the <strong>authentication</strong> procedure and the user passwords are <strong>encrypted</strong> to a <strong>SHA256 hash</strong> before saving to the database.</p>
<p>SQLite database engine is used for persistence.</p>
<p>Unit tests are also included.</p>

# Deployment
## Server machine requirements:
* Net Core 3.0 Runtime & Hosting Bundle
* IIS properly configured

## Client deployment Requirements
* The node packages which are excluded from the Git repository (npm install before ng -build)
* API url inside the environment
* IIS properly configured for the client serving machine
