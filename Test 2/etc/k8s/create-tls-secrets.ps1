mkcert `
"test_2-st-authserver" `
"test_2-st-angular" `
"test_2-st-public-web" `
"test_2-st-gateway-web" "test_2-st-gateway-web-public" `
"test_2-st-identity" "test_2-st-administration" "test_2-st-saas" "test_2-st-product" 
kubectl create namespace test_2
kubectl create secret tls -n test_2 test_2-tls --cert=./test_2-st-authserver+8.pem  --key=./test_2-st-authserver+8-key.pem