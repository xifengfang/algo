function serialize(obj){

	let t = typeof (obj);
	if (t != "object" || obj === null) {
		if (t == "string"){
			obj = '"'+obj+'"';
		}
		return String(obj);
	}
	else {
		let json = [];
		let isArr = (obj && obj.constructor == Array);

		for (let prop in obj) {
			let val = obj[prop]; 
			let vType = typeof(val);

			if (vType == "string"){
				val = '"'+val+'"';
			}
			else if (vType == "object" && val !== null){
				val = serialize(val);
			}

			json.push((isArr ? "" : '"' + prop + '":') + String(val));
		}

		return (isArr ? "[" : "{") + String(json) + (isArr ? "]" : "}");
	}
};

const car = {
    "make": "honda",
    "automatic": true,
    "price": 20000.00,
    "features": [
        "panoromic moonroof",
        "lane change indicator"
    ],
    "availalbleAt": {
        "dealerName": "Howdy Honda",
        "aadress": {
            "line1": "123 lane",
            "city": "Austin",
            "state": "TX"
        }
    }
}

const serializedValue = serialize(car);
console.log(serializedValue);
