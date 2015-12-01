# pcf-book-service
A simple web application with an ASP.NET Web API back end. Uses Entity Framework 6 for the data layer.

References:

1) [ASP.Net Web-API Example] (http://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework/part-1) (steps 1-4).

2) [API Help Pages Example] (http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/creating-api-help-pages).

3) [cURL] (http://curl.haxx.se/download.html)

```
Note:
When creating the API Help pages in this project, file ~/App_Data/XmlDocument.xml 
must be included in the project or it will not be published for deployment.
```
```
Examples:
1) Create a new book with an existing author:
curl -i -X POST -H "Content-Type: application/json" http://pcf-book-service.west-1.fe.gopivotal.com/api/books -d '{"Title":"Book Title","Year":2105,"Price":19.95,"Genre":"Fantasy","AuthorId":1}'
2) Create a new book and a new author:
curl -i -X POST -H "Content-Type: application/json" http://pcf-book-service.west-1.fe.gopivotal.com/api/books -d '{"Title":"Book Title","Year":2105,"Price":19.95,"Genre":"Fantasy","Author": {"Name":"Public, John Q."}}'
```
