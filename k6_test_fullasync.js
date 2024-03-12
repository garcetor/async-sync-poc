import http from "k6/http";

export const options = {
  iterations: 10,
};

let params = {
  timeout: '300s'
};

export default function () {
  const response = http.get("https://app-asyncsync-client-api.azurewebsites.net/api/run-test/fullasync", params);
}
