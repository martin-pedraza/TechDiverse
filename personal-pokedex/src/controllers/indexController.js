const pokemonList = require('../data/pokemon.json');

const indexController = {
	home: (req, res) => {
		res.render('index');
	},
	list: (req, res) => {
		let type = req.params.type.toUpperCase();
		let pokemonType = [];

		for (const p of pokemonList) {
			for (let j = 0; j < p.type.length; j++) {
				if (p.type[j] == type) {
					pokemonType.push(p);
				}
			}
		}

		res.render('pokemon', { pokemonType });
	},
	detail: (req, res) => {
		let pokemonDetail;
		for (const p of pokemonList) {
			if (p.name == req.params.name) {
				pokemonDetail = p;
			}
		}

		res.render('details', { pokemonDetail });
	}
};

module.exports = indexController;
