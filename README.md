# docker-lessions


run docker-compose up

or docker-compose build to just build the images

nodeapp -> api implemented in nodejs with two endpoints 
/api/area/circle
/api/area/rectangle

aspnetapp -> web mvc project that invokes the two apis 
access the page at localhost:51789/area


create a free style jenkins project

in the build step
cd nodeapp
sudo docker build -t nodeapp:dev .
sudo docker run --name nodeapp1 -p 8089:80 -d nodeapp:dev 
