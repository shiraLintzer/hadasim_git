const mongoose = require("mongoose");
const Joi = require("joi");
const jwt = require("jsonwebtoken");
let vaccinationSchema = new mongoose.Schema({
    userId: String,
    vaccinationNumber: Number,
    manufacturer: String,
    
});
exports.VaccinationModel = mongoose.model("Vaccinations", vaccinationSchema);

exports.validVaccinations = (_reqBody) => {
    let joiSchema = Joi.object({
        userId: Joi.string().min(5).max(9).required(),
        vaccinationNumber: Joi.number().min(0).max(4).required(),
        manufacturer: Joi.string().min(1).max(99).required()
    });
    return joiSchema.validate(_reqBody);
}