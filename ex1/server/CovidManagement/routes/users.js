const express = require("express");
const { UserModel } = require("../models/userModel");
const router = express.Router();



// create user
router.post("/", async (req, res) => {
  try {
    let user = new UserModel(req.body);
    await user.save();
    res.status(201).json(user)
  }
  catch (err) {
    console.log(err)
    res.status(500).json({ msg: "err", err })
  }
});


//get all users
router.get("/", async (req, res) => {
  try {
    
    let data = await UserModel.find({});
    
    res.json(data)
  }
  catch (err) {
    console.log(err)
    res.status(500).json({ msg: "err", err })
  }
});


//get user info
router.get("/:myInfo", async (req, res) => {
  try {
    let userId = req.params.myInfo
    let userInfo = await UserModel.findOne({ id: userId });
    res.json(userInfo);
  }
  catch (err) {
    console.log(err)
    res.status(500).json({ msg: "err", err })
  }
});



//edit user
router.put("/:idEdit", async (req, res) => {
  try {
    let editId = req.params.idEdit;
    let data;
    data = await UserModel.updateOne({ id: editId }, req.body);
    res.json(data);
  }
  catch (err) {
    console.log(err);
    res.status(500).json({ msg: "err", err })
  }
});



// delete user
router.delete("/:idDel", async (req, res) => {
  try {
    let delId = req.params.idDel;
    let data = await UserModel.deleteOne({ id: delId });
    res.json(data);
  } catch (err) {
    console.log(err);
    res.status(500).json({ msg: "There is an error, try again later", err });
  }
});

module.exports = router;
