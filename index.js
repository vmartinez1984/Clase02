//console.log("Hola mundo")

const express = require("express")
const app = express()
const port = 3000

app.get("/", (req, res) => {
    const idDto ={
        id: 1,
        encodedkey: "",
        mensaje: "Hola mundo"
    }
    res.status(200).json(idDto)
})

app.listen(port, () => {
    console.log("http://localhost:" + port)
});