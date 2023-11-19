const express = require('express');
const jwt = require('jsonwebtoken');
const jwksClient = require('jwks-rsa');

const cors = require('cors');
const app = express();
app.use(cors());
const client = jwksClient({
  jwksUri: 'https://dev-qoa8c8pxfm0stq6b.us.auth0.com/.well-known/jwks.json' // Replace with your Auth0 domain
});

function getKey(header, callback) {
  client.getSigningKey(header.kid, function(err, key) {
    const signingKey = key.publicKey || key.rsaPublicKey;
    callback(null, signingKey);
  });
}

app.get('/hello', (req, res) => {
  const token = req.headers['authorization']?.split(' ')[1];

  if (!token) {
    return res.status(401).send('Unauthorized: No token provided');
  }

  jwt.verify(token, getKey, function(err, decoded) {
    if (err) {
      return res.status(403).send('Forbidden: Invalid token');
    }

    if (decoded && decoded.permissions && decoded.permissions.includes('api')) {
      return res.send('Hello');
    } else {
      return res.status(403).send('Forbidden: Missing "api" permission');
    }
  });
});

const PORT = 3000;
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
