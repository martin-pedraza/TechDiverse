var express = require('express');
var router = express.Router();
const indexController = require('./../controllers/indexController');

/* GET home page. */
router.get('/', indexController.home);
router.get('/types/:type', indexController.list);
router.get('/details/:name', indexController.detail);

module.exports = router;
