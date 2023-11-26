const { defineConfig } = require("@vue/cli-service");
const { TsconfigPathsPlugin } = require("tsconfig-paths-webpack-plugin");

module.exports = defineConfig({
  transpileDependencies: true,
  configureWebpack: {
    resolve: {
      plugins: [new TsconfigPathsPlugin()],
    },
  },
});
