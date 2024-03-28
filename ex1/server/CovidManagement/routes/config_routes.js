const indexR = require("./index");
const vaccinationsR = require("./vaccinations");
const usersR = require("./users");

exports.routeInit = (app) => {
    app.use("/", indexR);
    app.use("/vaccinations", vaccinationsR);
    app.use("/users", usersR);
}