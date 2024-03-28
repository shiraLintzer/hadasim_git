const mongoose = require("mongoose");
const Joi = require("joi");
const jwt = require("jsonwebtoken");
const { config } = require("../config/secret");

let userSchema = new mongoose.Schema({
    
        id: String,
        fullName: {
            firstName:String,
            lastName: String,
        },
        birthDate: Date,
        phone: String,
        cellphone:String,
        address: {
            city: String,
            street:String,
            number:Number,
        },
        positiveTestDate: Date,
        recoveryDate: Date,
});
exports.UserModel = mongoose.model("users", userSchema);


