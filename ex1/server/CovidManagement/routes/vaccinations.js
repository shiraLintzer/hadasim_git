const express = require("express");
const { VaccinationModel, validVaccinations } = require("../models/vaccinationModel");
const router = express.Router();




//get single user vaccinations
router.get("/:userId", async (req, res) => {
  try {
      let userId = req.params.userId
      let data = await VaccinationModel.find({ userId: userId })
      res.json(data);
  }
  catch (err) {
      res.status(500).json({ msg: "There is error try again later" }, err);
  }
});


  //get All vaccinations
router.get("/", async (req, res) => {
    try {
      let vaccinationsInfo = await VaccinationModel.find({  });
      res.json(vaccinationsInfo);
    }
    catch (err) {
      console.log(err)
      res.status(500).json({ msg: "err", err })
    }
  });


// create vaccination
router.post("/", async (req, res) => {
    let valdiateBody = validVaccinations(req.body);
    if (valdiateBody.error) {
      
      return res.status(400).json(valdiateBody.error.details)
    }
    try {
      
      let vaccination = new VaccinationModel(req.body);
      await vaccination.save();
      res.status(201).json(vaccination)
    }
    catch (err) {
      console.log(err)
      res.status(500).json({ msg: "err", err })
    }
  });


  // delete vaccinations of user
router.delete("/:idDel", async (req, res) => {
  try {
    let delId = req.params.idDel;
    let data = await VaccinationModel.deleteMany({ userId: delId });
    res.json(data);
  } catch (err) {
    console.log(err);
    res.status(500).json({ msg: "There is an error, try again later", err });
  }
});


module.exports = router;