mkcert `
"test3-st-authserver" `
"test3-st-angular" `
"test3-st-public-web" `
"test3-st-gateway-web" "test3-st-gateway-web-public" `
"test3-st-identity" "test3-st-administration" "test3-st-saas" "test3-st-product" 
kubectl create namespace test3
kubectl create secret tls -n test3 test3-tls --cert=./test3-st-authserver+8.pem  --key=./test3-st-authserver+8-key.pem