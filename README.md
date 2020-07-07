# Blog Microservice that use google blogger api 

This app using:
* .Net Core
* WebApi Framework
* Polly

## Service

1. Method: Get
https://localhost:44381/api/post/getAll?language=ru

Response:
[{"categories":["test1","test2","test3","test4"],"id":27641495744360790,"type":"blogger#post","title":"test1 ",
"content":"test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1&nbsp;",
"createdDate":"2020-07-05T16:12:00+03:00","updatedDate":"2020-07-05T16:12:48+03:00",
"author":{"id":464711435371335774,"displayName":"WebMonitor24",
"imageUrl":"//lh3.googleusercontent.com/zFdxGE77vvD2w5xHy6jkVuElKv-U9_9qLkRYK8OnbDeJPtjSZ82UPq5w6hJ-SA=s35"}}]

2. Method: Get
https://localhost:44381/api/post/get?Language=ru&postId=27641495744360790

Response:
{"categories":["test1","test2","test3","test4"],
"id":27641495744360790,"type":"blogger#post","title":"test1 ",
"content":"test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1 test1&nbsp;",
"createdDate":"2020-07-05T16:12:00+03:00","updatedDate":"2020-07-05T16:12:48+03:00",
"author":{"id":464711435371335774,"displayName":"WebMonitor24",
"imageUrl":"//lh3.googleusercontent.com/zFdxGE77vvD2w5xHy6jkVuElKv-U9_9qLkRYK8OnbDeJPtjSZ82UPq5w6hJ-SA=s35"}}

3. Methos: Get
https://localhost:44381/api/page/getAll?language=ru

4. Methos: Get
https://localhost:44381/api/page/get?language=ru&pageId=1563006982329835026


## Database

This events logger use local MsSql database that located in ...\MicroServices\Microservice-EventLogger\EventLogger\LocalDB