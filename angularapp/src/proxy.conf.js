const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/Usuarios"
    ],
    target: "https://localhost:7041",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
