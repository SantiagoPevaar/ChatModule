mkcert `
"test1-st-authserver" `
"test1-st-angular" `
"test1-st-public-web" `
"test1-st-gateway-web" "test1-st-gateway-web-public" `
"test1-st-identity" "test1-st-administration" "test1-st-saas" "test1-st-product" 
kubectl create namespace test1
kubectl create secret tls -n test1 test1-tls --cert=./test1-st-authserver+8.pem  --key=./test1-st-authserver+8-key.pem