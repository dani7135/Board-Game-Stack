const PROXY_CONFIG = [
  {
    context: [
      "/boardgame",
    ],
    target: "https://localhost:7186",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
