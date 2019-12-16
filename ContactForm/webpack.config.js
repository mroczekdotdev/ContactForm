const path = require("path");
const outputDir = "./wwwroot/";
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
  mode: "production",
  entry: {
    index: "./webpack.index.js",
  },
  output: {
    path: path.resolve(__dirname, outputDir),
    filename: "site.js",
  },
  module: {
    rules: [
      {
        test: /\.js$/i,
        use: "babel-loader",
      },
      {
        test: /\.(css|scss|sass)$/i,
        use: [MiniCssExtractPlugin.loader, "css-loader", "sass-loader"],
      },
    ],
  },
  resolve: {
    extensions: [".js", ".css", ".scss"],
  },
  plugins: [
    new MiniCssExtractPlugin({
      filename: "site.css",
    }),
  ],
};
