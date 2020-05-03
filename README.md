# openrmf-api-report
This is the OpenRMF Reports API for running reports with data formatted for quick querying.

/swagger/ gives you the API structure.

## Making your local Docker image
* make build
* make latest

## creating the user
* ~/mongodb/bin/mongo 'mongodb://root:myp2ssw0rd@localhost'
* use admin
* db.createUser({ user: "openrmfreport" , pwd: "openrmf1234!", roles: ["readWriteAnyDatabase"]});
* use openrmfreport

## connecting to the database collection straight
~/mongodb/bin/mongo 'mongodb://openrmfreport:openrmf1234!@localhost/openrmfreport?authSource=admin'

## Using Jaeger

The Jaeger Client is https://github.com/jaegertracing/jaeger-client-csharp. We use defaults but you can specify ENV for configuration.