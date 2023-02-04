using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace GlobalGameJam
{
    public class PlayerControls : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 1f;

        [SerializeField] private GameObject _projectilePrefab;

        [SerializeField] private float _timeToShotAgainInSeconds = 0.3f;

        [SerializeField] private float _knockbackDrag = 0.05f;

        [SerializeField] private Transform _maxLeft;

        [SerializeField] private Transform _maxRight;

        [SerializeField] private Slider _slider;

        // [SerializeField]
        // private int _maxAmmo;

        [SerializeField] private int _ammo;

        [SerializeField] private GameObject _pickupAmmoObject;

        private Rigidbody2D _rigidbody;
        private Vector2 _moveDirection;
        private Vector2 _shootDirection;
        private Camera _mainCam;
        private float _shootTimer;
        private bool _mousePressed;
        private bool _isDigging;

        [field: SerializeField] public float KnockbackVelocityX { get; set; }

        public Vector2 Movement { get; private set; }

        [SerializeField] private AudioPlayer _audioPlayer;

        public Vector2 Input
        {
            get => _moveDirection;
            set
            {
                _moveDirection = value;
                if (_moveDirection.sqrMagnitude > _moveDirection.normalized.sqrMagnitude)
                    _moveDirection.Normalize();
            }
        }

        public Vector2 LookDir
        {
            get => _shootDirection;
            set => _shootDirection = value;
        }

        public int Ammo => _ammo;

        public bool IsDigging => _isDigging;

        public float SpeedModifier { get; set; } = 1f;

        private bool CanShoot => _shootTimer <= 0f;

        private void Awake()
        {
            _mainCam = Camera.main;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _shootTimer -= Time.deltaTime;
        }

        private void OnMove(InputValue value)
        {
            Input = value.Get<Vector2>();
        }

        private void OnShoot(InputValue value)
        {
            _mousePressed = value.Get<float>() > 0f;
            if (_mousePressed)
            {
                Vector2 playerToMouse = GetPlayerToMouseVec();
                _shootDirection = playerToMouse.normalized;
            }
            else
            {
                _shootDirection = Vector2.zero;
            }
        }

        private void OnLook(InputValue value)
        {
            _shootDirection = value.Get<Vector2>().normalized;
        }

        private void OnDig(InputValue value)
        {
            bool pressed = value.Get<float>() > 0f;
            if (pressed)
            {
                SpeedModifier = 0f;
                _isDigging = true;
                _slider.gameObject.SetActive(true);
                _pickupAmmoObject.SetActive(true);
            }
            else
            {
                SpeedModifier = 1f;
                _isDigging = false;
                _slider.gameObject.SetActive(false);
                _pickupAmmoObject.SetActive(false);
            }
        }

        private void FixedUpdate()
        {
            ApplyMovements();
            HandleShoot();
        }

        private void HandleShoot()
        {
            if (!CanShoot || _shootDirection == Vector2.zero) return;

            Shoot(_mousePressed ? GetPlayerToMouseVec().normalized : _shootDirection);
        }

        private void Shoot(Vector2 direction)
        {
            if (_ammo <= 0) return;

            if (!_mousePressed)
                _shootDirection = Vector2.zero;

            _shootTimer = _timeToShotAgainInSeconds;
            GameObject projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);

            var radvalue = Mathf.Atan2(direction.y, direction.x);
            var angle = radvalue * (180 / Mathf.PI);
            projectile.transform.rotation = Quaternion.Euler(0, 0, angle + -90);
            var behaviour = projectile.GetComponent<ProjectileBehaviour>();
            behaviour.Shoot(direction);
            _ammo -= 1;
            _audioPlayer.Play();
        }

        private void ApplyMovements()
        {
            var movement = new Vector2(_moveDirection.x, 0);
            movement *= _moveSpeed * SpeedModifier;
            movement.x += KnockbackVelocityX;
            Movement = movement;

            if (_maxLeft && _maxRight)
            {
                float posX = transform.position.x;
                bool isOutOfBound = posX < _maxLeft.position.x || posX > _maxRight.position.x;
                bool isGoingOutwards = Mathf.Sign(posX) * Mathf.Sign(Movement.x) > 0f;

                if (isOutOfBound && isGoingOutwards)
                {
                    Movement = Vector2.zero;
                }
            }

            _rigidbody.velocity = Movement;

            if (!Mathf.Approximately(KnockbackVelocityX, 0f))
            {
                KnockbackVelocityX -= _knockbackDrag * Mathf.Sign(KnockbackVelocityX);
            }
        }

        private Vector2 GetPlayerToMouseVec()
        {
            Vector2 pos = _mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            return pos - (Vector2) transform.position;
        }


        public void AddAmmo(int amount)
        {
            _ammo += amount;
        }
    }
}