var express = require('express')
var bodyParser = require('body-parser')
const port = 80
var app = express()

// create application/json parser
var jsonParser = bodyParser.json()
app.use(jsonParser);
// POST /login gets urlencoded bodies
app.post('/api/area/rectangle', function (req, res) {
    console.log(`rectangle api invoked - ${req.body.length} - ${req.body.width}`);
    let area = req.body.length * req.body.width;
    res.send({area});
})

// POST /api/users gets JSON bodies
app.post('/api/area/circle', function (req, res) {
    console.log(`circle api invoked -${req.body.radius}`);
    let area = 3.14 * req.body.radius;
    res.send({area});
})

app.listen(port, () => console.log(`Example app listening on port ${port}!`))