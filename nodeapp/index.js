var express = require('express')
var bodyParser = require('body-parser')
const port = 3000;
var app = express()

// create application/json parser
var jsonParser = bodyParser.json()
app.use(jsonParser);
// POST /login gets urlencoded bodies
app.post('/api/area/rectangle', function (req, res) {
    console.log(req);
    let area = req.body.length * req.body.width;
    res.send({area});
})

// POST /api/users gets JSON bodies
app.post('/api/area/circle', jsonParser, function (req, res) {
    let area = 3.14159 * req.body.radius;
    res.send({area});
})

app.listen(port, () => console.log(`Example app listening on port ${port}!`))